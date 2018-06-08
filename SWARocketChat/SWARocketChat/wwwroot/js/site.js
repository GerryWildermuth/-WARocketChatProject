// Write your JavaScript code.
$(function() {
    $('[data-toggle="tooltip"]').tooltip();
});

var SmallTable = $("#DatatableSmall").DataTable(
    {
        //scrollY: "74vh",
        //scrollCollapse: true,
        hover: true,
        sort:false
    });
var ChannelTable = $("#DatatableChannel").DataTable(
    {
        scrollY: "100vh",
        scrollCollapse: true,
        "paging": false,
        "ordering": false,
        "info": false
    });
$("#DatatableChannel_filter").hide();
$(function () {
    $("#SearchInput").on("keyup", function () {
        var filter = $(this).val();
        regex = "\\b" + filter + "\\b";
        SmallTable.search(filter, true, false).draw();
    });
});