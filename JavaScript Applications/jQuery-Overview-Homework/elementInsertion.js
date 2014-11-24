(function () {
    $(document).ready(function () {
        var newElement = $('<li>').text('Element');
        $('#beginning').click(function () {
            $('#elements').prepend(newElement);
        });
        $('#end').click(function () {
            $('#elements').append(newElement);
        });
    });
}());