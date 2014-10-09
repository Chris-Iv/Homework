<?php
session_start();
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>HTML Tags Counter</title>
    </head>
    <body>
        <form method="post">
            <label for="tag">Enter HTML tags:</label><br/>
            <input type="text" name="tag" id="tag"/>
            <input type="submit" name="submit" value="Submit"/>
        </form>
        <?php
        $tags = array("a", "abbr", "address", "area", "article", "aside", "audio", "b", "base", "bdi", "bdo", "blockquote", "body", "br", "button", "canvas", "caption",
            "cite", "code", "col", "colgroup", "command", "datalist", "dd", "del", "details", "dfn", "div", "dl", "dt", "em", "embed", "fieldset", "figcaption", "figure",
            "footer", "form", "h1", "h2", "h3", "h4", "h5", "h6", "head", "header", "hgroup", "hr", "html", "i", "iframe", "img", "input", "ins", "kbd", "keygen", "label",
            "legend", "li", "link", "map", "mark", "menu", "meta", "meter", "nav", "noscript", "object", "ol", "optgroup", "option", "output", "p", "param", "pre", "progress",
            "q", "rp", "rt", "ruby", "s", "samp", "script", "section", "select", "small", "source", "span", "strong", "style", "sub", "summary", "sup", "table", "tbody", "td",
            "textarea", "tfoot", "th", "thead", "time", "title", "tr", "track", "u", "ul", "var", "video", "wbr");
        if (!isset($_SESSION['score']) || !isset($_SESSION['tagsLeft'])) {
            $_SESSION['score'] = 0;
            $_SESSION['tagsLeft'] = $tags;
        }
        if ($_POST && isset($_POST['submit'])) {
            $tag = mb_strtolower(trim($_POST['tag']));
            if (array_search($tag, $tags) === false) {
                echo "Invalid HTML tag!";
            } else {
                echo "Valid HTML tag!";
                if (array_search($tag, $_SESSION['tagsLeft']) !== false) {
                    $_SESSION['score']++;
                    $key = array_search($tag, $tags);
                    unset($_SESSION['tagsLeft'][$key]);
                }
            }
        }
        echo "Score: " . $_SESSION['score'];
        ?>
    </body>
</html>