<h1>Search Issues</h1>
<form method="post" action="search">
    <label for="search">Search: </label>
    <br/>
    <input type="text" id="search" name="search"/>
    <br/>
    <input type="submit" value="Search"/>
</form>

<?php if($this->showResults): ?>
    <table>
        <tr>
            <th>ID</th>
            <th>Title</th>
            <th>State</th>
        </tr>
        <?php foreach($this->issues as $issue): ?>
            <tr>
                <td><?= $issue[0] ?></td>
                <td><?= htmlspecialchars($issue[1]) ?></td>
                <td><?= htmlspecialchars($issue[2]) ?></td>
                <td>
                    <button id="show-details">Show Details</button>
                    <script>var id = <?=$issue[0]?>;</script>
                    <div id="details"></div>
                </td>
                <td>
                    <?php if ($this->isLoggedIn): ?>
                        <a id="button" href="/issues/edit/<?=$issue[0]?>">[Edit]</a>
                    <?php endif; ?>
                </td>
                <td>
                    <?php if ($this->isAdmin): ?>
                        <a id="button" href="/issues/delete/<?=$issue[0]?>">[Delete]</a>
                    <?php endif; ?>
                </td>
            </tr>
        <?php endforeach; ?>
    </table>
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
<?php endif; ?>