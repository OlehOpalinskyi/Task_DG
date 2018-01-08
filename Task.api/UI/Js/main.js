$(function () {
    $.ajax({
        method: "get",
        url: "http://localhost:50663/api/news",
        success: function (data) {
            BuildTable(data);
        }
    });

    $('#byTime').click(function () {
        Sort("http://localhost:50663/api/news/byDate");
    });

    $('#byTitle').click(function () {
        Sort("http://localhost:50663/api/news/byTitle");
    })
});

function BuildTable(data) {
    var table = "";
    for (var i = 0; i < data.length; i++) {
        table += "<tr><td>" + data[i].time + "</td><td>" + data[i].title + "</td></tr>";
    }
    $('#news').html(table);
}

function Sort(url) {
    $.ajax({
        method: 'get',
        url: url,
        success: function (data) {
            BuildTable(data);
        }
    })
}