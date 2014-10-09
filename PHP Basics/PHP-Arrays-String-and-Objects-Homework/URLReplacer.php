<?php
if (isset($_POST['text'])) {
    $text = $_POST['text'];
    $text = preg_replace('/<a href="(.*?)">/', '[URL=\1]', $text);
    $text = str_replace('</a>', '[/URL]', $text);
}
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <title>URL Replacer</title>
</head>
<body>
<form method="post">
    <textarea name="text"></textarea>
    <input type="submit" value="Replace"/>
</form>
<?php
if (isset($text)) {
    echo htmlentities($text);
}
?>
</body>
</html>