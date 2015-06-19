<html>
<head>
    <meta charset="utf-8">
    <title>Guess the number</title>
</head>
<body>
<form action="play.php" method="post">
    <label for="number">Enter a number in the range [1...100]: </label>
    <input type="text" name="number"/>
    <input type="submit" value="Guess"/>
</form>
</body>
</html>

<?php
session_start();
$number = $_SESSION['number'];
if (isset($_POST['name'])) {
    $_SESSION['userName'] = $_POST['name'];
}

if (isset($_POST['number'])) {
    $userNumber = $_POST['number'];
    $_SESSION['userNumber'] = $userNumber;
    if ($userNumber < $number) {
        echo "Up";
    } elseif ($userNumber > $number) {
        echo "Down";
    } else {
        echo "Congratulations, " . $_SESSION['userName'];
         echo "<form action='index.php' method='post'>
        <input type='submit' value='Play Again'/>
        </form>";
    }
}