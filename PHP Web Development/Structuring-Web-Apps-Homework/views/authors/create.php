<h1>Create New Author</h1>
<form action="/authors/create" method="post">
    <label for="author_name">Name: </label>
    <input type="text" name="author_name" value="<?= $this->getFieldValue('author_name') ?>"/>
    <?= $this->getValidationError('author_name') ?>
    <br/>
    <input type="submit" value="create"/>
</form>