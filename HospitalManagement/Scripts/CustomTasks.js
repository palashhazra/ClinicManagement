$(document).ready(function () {
    $(".datepicker").datepicker({
        dateFormat: "dd-mm-yy",
        changemonth: true,
        changeyear: true
    });
});

//$(function () {
//    $('.datetimepicker').datetimepicker({
//        //format: 'L',      
//        dateFormat: "dd/mm/yyyy",
//        changemonth: true,
//        changeyear: true
//    }).on('dp.change', function (e) {
//        var newDateTime = e.date.format('DD/MM/YYYY');

//        $('#DateOfBirth').val(newDateTime);
//        //alert(newDateTime);
//    });      
//}
//);


