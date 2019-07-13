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
var IndexTable = $("#DatatableIndex").DataTable(
    {
        scrollY: "95vh",
        scrollCollapse: true,
        "paging": false,
        "ordering": true,
        "sort": true,
        "fnInitComplete": function () {
            this.fnAdjustColumnSizing(true);
        } 
    });
$(window).resize(function () {
    if (IndexTable.exists)
        IndexTable.fnAdjustColumnSizing();
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
