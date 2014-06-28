/// <reference path="libs/require.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="app/controls.js" />
/// <reference path="app/data.js" />
require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        mustache: "libs/mustache",
        data: "app/data",
        controls: "app/controls"
    }
});

require(["jquery", "mustache", "data", "controls"], function ($, mustache, data, controls) {
    var personTemplateString = $("#student-template").html();
    var template = mustache.compile(personTemplateString);
    var comboBoxView = controls.ComboBox(data.getPeople());

    var ComboBoxHtml = comboBoxView.render(template);

    $("#content").html(ComboBoxHtml);

    $("#content").find('.person-list').on("click", "li", function () {
        $(this).siblings().hide();
        $(this).addClass("selected");
    });

    $("#content").find('.person-list').on("click", "li.selected", function () {
        $("li.selected").removeClass("selected");
        $(this).parent().children().show();
    });
});