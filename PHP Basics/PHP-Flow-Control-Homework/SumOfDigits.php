<?php
if (isset($_POST['input'])) {
    $input = explode(', ', $_POST['input']);
    $result = '<table border="1"><tbody>';
    for ($i = 0; $i < count($input); $i++) {
        $number = $input[$i];
        $result .= "<tr><td>$number</td><td>";
        if (is_numeric($number)) {
            $sum = array_sum(str_split($number));
            $result .= $sum;
        } else {
            $result .= "I cannot sum that";
        }
        $result .= '</td></tr>';
    }
    $result .= '</tbody></table>';
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Sum Of Digits</title>
    </head>
    <body>
        <form method="post">
            <label for="input">Input string:</label>
            <input type="text" name="input" id="input"/>
            <input type="submit" value="Submit"/>
        </form>
        <?php
        if (isset($result)) {
            echo $result;
        }
        ?>
    </body>
</html>