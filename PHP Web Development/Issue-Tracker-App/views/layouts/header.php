<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <link rel="stylesheet" href="/content/styles.css"/>
    <title><?php if (isset($this->title)) echo htmlspecialchars($this->title) ?></title>
</head>
<body>
<header>
    <a href="/"><img src="/content/images/issue_tracker_logo.png" alt="issue_tracker_logo"/></a>
    <ul>
        <li><a href="/">Home</a></li>
        <li><a href="/search">Search</a></li>
        <?php if ($this->isLoggedIn) : ?>
            <li><a href="/issues/create">Create Issue</a></li>
        <?php endif ?>
    </ul>
    <?php if ($this->isLoggedIn) : ?>
        <div id="logged-in-info">
            <span>Hello, <?= $_SESSION['username'] ?></span>
            <form method="post" action="/account/logout"><input type="submit" value="Logout"/></form>
        </div>
    <?php endif ?>
    <?php if(!$this->isLoggedIn) : ?>
        <div id="login-or-register">
            <a href="/account/login">Login</a>
            <a href="/account/register">Register</a>
        </div>
    <?php endif ?>
</header>
<?php include('/views/layouts/messages.php'); ?>