﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.edit-icon, .delete-icon').tooltip({
        position: {
            my: 'center top',
            at: 'center bottom'
        }
    });
    $("#datepicker").datetpicker({
        dateFormat: 'YY-MM-DD'
    });
});





