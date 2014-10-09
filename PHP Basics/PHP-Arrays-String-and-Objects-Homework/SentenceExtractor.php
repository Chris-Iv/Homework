<?php
if (isset($_POST['text']) && isset($_POST['word'])) {
    $sentences = preg_split("/(?<=[.?!])\s*/", $_POST['text'], -1, PREG_SPLIT_NO_EMPTY);
    $word = $_POST['word'];
    $result = "";
    foreach ($sentences as $sentence) {
        if (preg_match("/\s+$word\s+.*[.?!]+$/", $sentence)) {
            $result .= $sentence . '<br/>';
        }
    }
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Sentence Extractor</title>
    </head>
    <body>
        <form method="post">
            <textarea name="text"></textarea>
            <input type="text" name="word"/>
            <input type="submit" value="Extract"/>
        </form>
        <?php
        if (isset($result)) {
            echo $result;
        }
        ?>
    </body>
</html>