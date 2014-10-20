<?php
$text = $_GET['text'];
$blacklist = preg_split("/[*\s]+/", $_GET['blacklist'], -1, PREG_SPLIT_NO_EMPTY);
$emailPattern = "/[A-Za-z0-9+_-]+@[A-Za-z0-9-]+\.[A-Za-z0-9-\.]+/";
$newText = preg_replace_callback($emailPattern, 'replace', $text);
echo "<p>$newText</p>";

function replace($match) {
    $email = $match[0];
    if (shouldBlacklist($email)) {
        return str_repeat("*", strlen($email));
    } else {
        return "<a href=\"mailto:$email\">$email</a>";
    }
}

function shouldBlacklist($email) {
    global $blacklist;
    foreach ($blacklist as $blacklistItem) {
        if (startsWith($blacklistItem, ".")) {
            if (endsWith($email, $blacklistItem)) {
                return true;
            }
        } else if ($email === $blacklistItem) {
            return true;
        }
    }
    return false;
}

function startsWith($location, $target)
{
    return $target === "" || strpos($location, $target) === 0;
}

function endsWith($location, $target)
{
    return $target === "" || substr($location, -strlen($target)) === $target;
}
?>