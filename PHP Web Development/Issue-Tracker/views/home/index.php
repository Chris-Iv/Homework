<h1>Issues</h1>
<aside>
    <table>
        <tr>
            <th>States</th>
        </tr>
        <tr>
            <td><a href="/home/index/<?= $this->page ?>/<?= $this->pageSize ?>/All">All</a></td>
        </tr>
        <tr>
            <td><a href="/home/index/<?= $this->page ?>/<?= $this->pageSize ?>/New">New</a></td>
        </tr>
        <tr>
            <td><a href="/home/index/<?= $this->page ?>/<?= $this->pageSize ?>/Open">Open</a>
        </tr>
        <tr>
            <td><a href="/home/index/<?= $this->page ?>/<?= $this->pageSize ?>/Fixed">Fixed</a>
        </tr>
        <tr>
            <td><a href="/home/index/<?= $this->page ?>/<?= $this->pageSize ?>/Closed">Closed</a></td>
        </tr>
    </table>
</aside>
<table>
    <tr>
        <th>ID</th>
        <th>Title</th>
        <th>State</th>
    </tr>
    <?php foreach($this->issues as $issue): ?>
        <tr>
            <td id="issue-id"><?= $issue[0] ?></td>
            <td><?= htmlspecialchars($issue[1]) ?></td>
            <td><?= htmlspecialchars($issue[2]) ?></td>
            <td>
                <button id="show-details">Show Details</button>
                <script>var id = document.getElementById('issue-id').innerText;</script>
                <div id="details"></div>
            </td>
            <td>
            <?php if($this->isLoggedIn): ?>
                <a id="button" href="/issues/edit/<?=$issue[0]?>">[Edit]</a>
            <?php endif ?>
            </td>
            <td>
                <?php if($this->isAdmin): ?>
                    <a id="button" href="/issues/delete/<?=$issue[0]?>">[Delete]</a>
                <?php endif ?>
            </td>
        </tr>
    <?php endforeach; ?>
</table>
<a id="button" href="/home/index/<?= $this->page - 1 ?>/<?= $this->pageSize ?>">[Previous]</a>
<a id="button" href="/home/index/<?= $this->page + 1 ?>/<?= $this->pageSize ?>">[Next]</a>
<script src="/libs/jquery-2.1.1.min.js"></script>
<script>
    $('#show-details').on('click', function (event) {
        $.ajax({
            url: '/home/showDetails/' + id,
            method: 'GET'
        }).success(function (data) {
            $('#details').html(data);
        })
    });
</script>