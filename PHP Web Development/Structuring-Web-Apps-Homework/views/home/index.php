<h1>Welcome to home</h1>
<a href="/account/login">[Login]</a>
<a href="/account/register">[Register]</a>
<?php if($this->isLoggedIn): ?>
<button id="show-books">Show Books</button>
<?php endif; ?>
<div id="books"></div>
<script src="/libs/jquery-2.1.1.min.js"></script>
<script>
    $('#show-books').on('click', function (event) {
        $.ajax({
            url: '/books/showBooks',
            method: 'GET'
        }).success(function (data) {
            $('#books').html(data);
        })
    });
</script>