function checkParams() {
    var search = $('#search').val();

    if (search.length != 0) {
        $('#submit').removeAttr('disabled');
    } else {
        $('#submit').attr('disabled');
    }
}