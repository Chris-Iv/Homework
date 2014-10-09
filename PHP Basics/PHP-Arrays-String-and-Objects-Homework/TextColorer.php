<?php
if (isset($_POST['input'])) {
    $text = $_POST['input'];
    $result = "";
    for ($i = 0; $i < strlen($text); $i++) {
        if (ord($text[$i]) % 2 == 0) {
            $result .= "<span class='red'>$text[$i] </span>";
        } else {
            $result .= "<span class='blue'>$text[$i] </span>";
        }
    }
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Text Colorer</title>
        <style>
            .red {
                color: red;
            }
            .blue {
                color: blue;
            }
        </style>
    </head>
    <body>
        <form method="post">
            <textarea name="input"></textarea>
            <input type="submit" value="Color text"/>
        </form>
        <?php
        if (isset($result))
        echo $result;
        ?>
    </body>
</html>