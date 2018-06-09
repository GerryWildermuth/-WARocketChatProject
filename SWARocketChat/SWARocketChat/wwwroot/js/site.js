// Write your JavaScript code.
$(function() {
    $('[data-toggle="tooltip"]').tooltip();
});

var SmallTable = $("#DatatableSmall").DataTable(
    {
        scrollY: "85vh",
        scrollCollapse: true,
        "paging": false,
        "ordering": false,
        "sort":false
    });
var ChannelTable = $("#DatatableChannel").DataTable(
    {
        scrollY: "85vh",
        scrollCollapse: true,
        "paging": false,
        "ordering": false,
        "info": false
    });
$("#DatatableChannel_filter").hide();
$("#DatatableSmall_filter").hide();
$(function () {
    $("#SearchInput").on("keyup", function () {
        var filter = $(this).val();
        regex = "\\b" + filter + "\\b";
        SmallTable.search(filter, true, false).draw();
    });
});