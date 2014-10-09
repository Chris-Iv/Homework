<?php
if (isset($_POST['text']) && isset($_POST['banlist'])) {
    $text = $_POST['text'];
    $banned = explode(', ', $_POST['banlist']);
    foreach ($banned as $word) {
        $text = str_replace($word, str_repeat("*", strlen($word)), $text);
    }
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Text Filter</title>
    </head>
    <body>
        <form method="post">
            <textarea name="text"></textarea>
            <input type="text" name="banlist"/>
            <input type="submit" value="Filter"/>
        </form>
        <?php
        if (isset($text)) {
            echo $text;
        }
        ?>
    </body>
</html>