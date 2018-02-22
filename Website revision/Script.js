function append(ParentSelector, Tag, Class, Html)
{
    var Parent = document.querySelector(ParentSelector);
    var Child = document.createElement(Tag);
    Child.innerHTML = Html;
    Child.className += Class;
    parent.appendChild(Child);
}



function getJSON(url, callback)
{
    var request = new XMLHttpRequest();
    request.open('GET', url, true);
    request.onload = function ()
    {
        if (request.status === 200)
        {
            var data = JSON.parse(request.responseText);
            callback(data);
        }
    };
    request.send();
}

function ready(fn)
{
    if (document.readyState !== 'loading')
    {
        fn();
    }
    else
    {
        document.addEventListener('DOMContentLoaded', fn);
    }
}

function GetRepos(username, ID)
{
    var url = "https://api.github.com/users/" + username + "/repos?per_page=1000";
    getJSON(url, function (response) {
        updateRepoDetail(response, ID);
        updateLastPush(lastPushedDay(response), ID);
    });
}

function updateLastPush(lastDay, ID)
{
    append(ID + " .gh-active-time", "span", "", 'Last active: ' + (lastDay ? lastDay + ' day(s) ago' : 'Today'));
}

function lastPushedDay(repos)
{
    var now = new Date();
    var latestDate;
    var difference = 9999999999999;
    for (var i = 0; i < repos.length; i++)
    {
        var pushedDate = new Date(repos[i].pushed_at);
        if (now - pushedDate < difference)
        {
            latestDate = pushedDate;
            difference = now - pushedDate;
        }
    }
    return Math.floor((now - latestDate) / (1000 * 3600 * 24));
}

function updateRepoDetail(repos, ID)
{
    for(var i = 0; i < repos.length; i++)
    {
        var language = repos[i].language ? repos[i].language : "Unknown";
        append(ID + ".gh-repositories", "div", "gh-container", '<div class="gh-item names"><div><a class="gh-link" href="' + repos[i].repoUrl + '">' + repos[i].name + '</a></div></div><div class="gh-item language"><div>' + language + '</div></div><div class="gh-item stars"><div>&#9733;' + repos[i].stars + '</div></div>');
    }
}

function topRepos(repos)
{

    repos.sort(function (a, b)
    {
        if (a.stargazers_count === b.stargazers_count)
        {
            return 0;
        } else if (a.stargazers_count > b.stargazers_count)
        {
            return -1;
        } else
        {
            return 1;
        }
    })

    repos = repos.slice(0, 3);
    var result = [];
    for (var i in repos)
    {
        var repo = repos[i];
        result.push(
            {
            name: repo.name,
            stars: repo.stargazers_count,
            language: repo.language,
            repoUrl: repo.html_url
        });
    }
    return result;
}