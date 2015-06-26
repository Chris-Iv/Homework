<h1><?php if (isset($this->title)) echo htmlspecialchars($this->title) ?></h1>
<table>
    <tr>
        <th>Id</th>
        <th>Title</th>
    </tr>
    <?php foreach($this->books as $book): ?>
        <tr>
            <td><?= $book[0] ?></td>
            <td><?= $book[1] ?></td>
        </tr>
    <?php endforeach; ?>
</table>
<a href="/books/index/<?= $this->page - 1 ?>/<?= $this->pageSize ?>">Previous</a>
<a href="/books/index/<?= $this->page + 1 ?>/<?= $this->pageSize ?>">Next</a>