$(function() {
    $("#datepicker").datepicker({
        dateFormat: "dd.mm.yy",
        regional: "bg",
        maxDate: 0
    }).attr('readonly','readonly');
});