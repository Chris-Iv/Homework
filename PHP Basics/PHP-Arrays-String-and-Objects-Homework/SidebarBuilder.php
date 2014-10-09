<?php
if (isset($_POST['category']) && isset($_POST['tag']) && isset($_POST['month'])) {
    $categories = explode(', ', $_POST['category']);
    $tags = explode(', ', $_POST['tag']);
    $months = explode(', ', $_POST['month']);
    $result = '<aside><section><h2>Categories</h2><hr/><ul>';
    for ($i = 0; $i < count($categories); $i++) {
        $category = "<a href='#'>$categories[$i]</a>";
        $result .= "<li>$category</li>";
    }
    $result .= '</ul></section><section><h2>Tags</h2><hr/><ul>';
    for ($i = 0; $i < count($tags); $i++) {
        $tag = "<a href='#'>$tags[$i]</a>";
        $result .= "<li>$tag</li>";
    }
    $result .= '</ul></section><section><h2>Months</h2><hr/><ul>';
    for ($i = 0; $i < count($months); $i++) {
        $month = "<a href='#'>$months[$i]</a>";
        $result .= "<li>$month</li>";
    }
    $result .= '</ul></section></aside>';
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Sidebar Builder</title>
    </head>
    <body>
        <form method="post">
            <label for="category">Categories:</label>
            <input type="text" name="category" id="category"/>
            <label for="tag">Tags:</label>
            <input type="text" name="tag" id="tag"/>
            <label for="month">Months:</label>
            <input type="text" name="month" id="month"/>
            <input type="submit" value="Generate"/>
        </form>
        <?php
        if (isset($result)) {
            echo $result;
        }
        ?>
    </body>
</html>