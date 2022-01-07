// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ajaxGet(url) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#modal-window .modal-body").html(res);
            $("#modal-window").modal("show");
        }
    })
}