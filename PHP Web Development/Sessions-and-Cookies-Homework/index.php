<html>
<head>
    <meta charset="utf-8">
    <title>Guess the number</title>
</head>
<body>
<form action="play.php" method="post">
    <label for="name">Name: </label>
    <input type="text" name="name"/>
    <input type="submit" value="Start Game"/>
</form>
</body>
</html>

<?php
session_start();
$number = rand(1, 100);
$_SESSION['number'] = $number;