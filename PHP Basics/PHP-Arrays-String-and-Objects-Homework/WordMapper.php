<?php
if (isset($_POST['input'])) {
    $words = preg_split('/\W+/', strtolower($_POST['input']), -1, PREG_SPLIT_NO_EMPTY);
    $arr = [];
    foreach ($words as $word) {
        if (isset($arr[$word])) {
            $arr[$word]++;
        } else {
            $arr[$word] = 1;
        }
    }
    arsort($arr);
    $result = '<table><tbody>';
    foreach ($arr as $word => $value) {
        $result .= "<tr><td>$word</td><td>$value</td></tr>";
    }
    $result .= '</tbody></table>';
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Word Mapper</title>
    </head>
    <body>
        <form method="post">
            <textarea name="input"></textarea>
            <input type="submit" value="Count words"/>
        </form>
        <?php
        if (isset($result)) {
            echo $result;
        }
        ?>
    </body>
</html>