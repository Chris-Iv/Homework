(function () {
    function logIn(e) {
        var username = $('#username').val();
        localStorage.setItem('username', username);
    }

    if (!localStorage['visitsCount']) {
        localStorage.setItem('visitsCount', 0);
    }

    if (!sessionStorage['visitsCount']) {
        sessionStorage.setItem('visitsCount', 0);
    }

    var username = localStorage['username'];
    var totalCount = localStorage['visitsCount'];
    var sessionCount = sessionStorage['visitsCount'];

    totalCount++;
    sessionCount++;

    $('<div>').text('Total visits: ' + totalCount).appendTo('body');
    $('<div>').text('Session visits: ' + sessionCount).appendTo('body');

    if (localStorage['username']) {
        $('form').hide();
        $('#geeting').text('Hello ' + username);
    } else {
        $('#loginButton').click(logIn);
    }
}());