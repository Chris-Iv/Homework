<?php
if (isset($_POST['input']) && isset($_POST['select'])) {
    $input = htmlentities($_POST['input']);
    $selected = $_POST['select'];
    $result = "";
    if ($selected == "palindrome") {
        if ($input == strrev($input)) {
            $result = "$input is a palindrome!";
        } else {
            $result = "$input is not a palindrome!";
        }
    } else if ($selected == "reverse") {
        $result = strrev($input);
    } else if ($selected == "split") {
        $array = str_split($input);
        $array = array_filter($array, function($val) {
            if ($val == ' ') {
                return false;
            }
            return true;
        });
        $result = implode($array, ' ');
    } else if ($selected == "hash") {
        $result = crypt($input);
    } else if ($selected == "shuffle") {
        $result = str_shuffle($input);
    }
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>String Modifier</title>
    </head>
    <body>
        <form method="post">
            <input type="text" name="input"/>
            <input type="radio" name="select" id="palindrome" value="palindrome"/>
            <label for="palindrome">Check Palindrome</label>
            <input type="radio" name="select" id="reverse" value="reverse"/>
            <label for="reverse">Reverse String</label>
            <input type="radio" name="select" id="split" value="split"/>
            <label for="split">Split</label>
            <input type="radio" name="select" id="hash" value="hash"/>
            <label for="hash">Hash String</label>
            <input type="radio" name="select" id="shuffle" value="shuffle"/>
            <label for="shuffle">Shuffle String</label>
            <input type="submit" value="Submit"/>
        </form>
        <?php
        if (isset($result)) {
            echo $result;
        }
        ?>
    </body>
</html>