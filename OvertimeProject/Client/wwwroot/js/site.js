// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var stringnip = $("#NIK").val();

$.ajax({
    url: 'https://localhost:44314/API/Requests/GetRequestByNIK/' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblReq").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=2&nik=' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblApv").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=3&nik=' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblRjc").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=0&nik=' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblWait").html(result.length);
}).fail((error) => {
    console.log(error);
});