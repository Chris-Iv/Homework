
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <title>Most Frequent Tag</title>
</head>
<body>
<form method="post" action="MostFrequentTag.php">
    <label for="tags">Enter Tags:</label><br/>
    <input type="text" name="tags" id="tags" required="true"/>
    <input type="submit" value="submit" name="submit"/>
</form>
<?php
if (isset($_POST['tags'])) {
    $text = htmlentities($_POST['tags']);
    $tags = explode(', ', $text);
    $countTags = array();
    foreach ($tags as $tag) {
        if (!isset($countTags[$tag])) {
            $countTags[$tag] = 1;
        } else {
            $countTags[$tag]++;
        }
    }
    arsort($countTags);
    foreach ($countTags as $key => $value) {
        echo $key . ':' . $value . 'times' . '<br/>';
    }
    echo('<br/>');
    echo "Most frequent tag is: " . array_keys($countTags)[0];
}
?>
</body>
</html>