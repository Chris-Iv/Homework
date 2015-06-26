<table>
    <tr>
        <td>
            Description: <?php if(isset($this->details['description'])) echo $this->details['description']; ?>
        </td>
    </tr>
    <tr>
        <td>
            Author: <?php if(isset($this->details['author'])) echo $this->details['author']; ?>
        </td>
    </tr>
    <tr>
        <td>
            State: <?php if(isset($this->details['state'])) echo $this->details['state']; ?>
        </td>
    </tr>
    <tr>
        <td>
            Submit Date and Time: <?php if(isset($this->details['submit_date'])) echo $this->details['submit_date']; ?>
        </td>
    </tr>
    <tr>
        <td>
            <?php if(isset($this->comments)): ?>
                <table>
                    Comments:
                    <?php foreach ($this->comments as $comment): ?>
                        <tr>
                            <td>
                                <?= htmlspecialchars($comment[2]) ?>
                            </td>
                            <td>
                                (by: <?= htmlspecialchars($comment[1]) ?>)
                            </td>
                            <td>
                                <?php if ($this->isAdmin): ?>
                                    <button id="edit-comment">Edit</button>
                                    <script>var id = <?=$comment[0]?>;</script>
                                    <div id="edit-comment-box"></div>
                                <?php endif; ?>
                            </td>
                            <td>
                                <?php if ($this->isAdmin): ?>
                                    <a id="button" href="/issues/deleteComment/<?=$comment[0]?>">[Delete]</a>
                                <?php endif; ?>
                            </td>
                        </tr>
                    <?php endforeach; ?>
                </table>
            <?php endif ?>
            <form method="post" action="/issues/addComment">
                <?php if(!$this->isLoggedIn): ?>
                    <label for="author">Author: </label>
                    <input type="text" name="author" id="author"/>
                    <br/>
                <?php endif ?>
                <label for="comment">Add comment: </label>
                <input type="text" name="comment" id="comment"/>
                <input type="submit" value="Comment"/>
            </form>
        </td>
    </tr>
</table>
<script src="/libs/jquery-2.1.1.min.js"></script>
<script>
    $('#edit-comment').on('click', function (event) {
        $.ajax({
            url: '/issues/editComment/' + id,
            method: 'GET'
        }).success(function (data) {
            $('#edit-comment-box').html(data);
        })
    });
</script>