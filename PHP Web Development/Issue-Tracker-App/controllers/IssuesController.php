<?php

class IssuesController extends BaseController {
    private $db;

    public function onInit() {
        $this->db = new IssuesModel();
    }

    public function create() {
        $this->authorize();
        $this->title = 'Create Issue';
        if ($this->isPost) {
            $title = $_POST['title'];
            $description = $_POST['description'];
            $state = $_POST['state'];
            $submit_date = date('Y-m-d H:i:s');
            $author = $_SESSION['username'];
            if (strlen($title) < 3) {
                $this->addErrorMessage('The title should be longer than 2');
                return $this->renderView(__FUNCTION__);
            }

            if (($state !== 'Open') && ($state !== 'Closed') && ($state !== 'Fixed') && ($state !== 'New')) {
                $this->addErrorMessage('The state is invalid');
                return $this->renderView(__FUNCTION__);
            }

            if ($this->db->createIssue($title, $description, $state, $submit_date, $author)) {
                $this->addInfoMessage('Issue created');
                $this->redirect('home');
            } else {
                $this->addErrorMessage('Error creating issue');
            }
        }

        $this->renderView(__FUNCTION__);
    }

    public function edit($id) {
        $this->authorize();
        $this->title = 'Edit Issue';
        if ($this->isPost) {
            $issue_id = $_SESSION['issue_id'];
            $title = $_POST['title'];
            $description = $_POST['description'];
            $state = $_POST['state'];
            if (strlen($title) < 3) {
                $this->addErrorMessage('The title should be longer than 2');
                $this->redirectToUrl('/issues/edit/' . $issue_id);
            }

            if (($state !== 'Open') && ($state !== 'Closed') && ($state !== 'Fixed') && ($state !== 'New')) {
                $this->addErrorMessage('The state is invalid');
                $this->redirectToUrl('/issues/edit/' . $issue_id);
            }

            if ($this->db->editIssue($issue_id, $title, $description, $state)) {
                $this->addInfoMessage('Issue edited');
                $this->redirect('home');
            } else {
                $this->addErrorMessage('Error editing issue');
            }
        }

        $_SESSION['issue_id'] = $id;
        $this->renderView(__FUNCTION__);
    }

    public function delete($id) {
        $this->admin();
        if ($this->db->deleteIssue($id)) {
            $this->addInfoMessage('Issue deleted');
        } else {
            $this->addErrorMessage('Cannot delete issue');
        }

        $this->redirect('home');
    }

    public function addComment() {
        if($this->isLoggedIn) {
            $author = $_SESSION['username'];
        } else {
            $author = $_POST['author'];
        }

        $text = $_POST['comment'];
        $issue_id = $_SESSION['issue_id'];
        if (strlen($text) < 1) {
            $this->addErrorMessage('The comment cannot be empty');
            return $this->renderView(__FUNCTION__);
        }

        if ($this->db->addComment($author, $text, $issue_id)) {
            $this->addInfoMessage('Comment added');
            $this->redirect('home');
        } else {
            $this->addErrorMessage('Error adding comment');
        }
    }

    public function editComment($id) {
        if ($this->isPost) {
            $comment_id = $_SESSION['comment_id'];
            $text = $_POST['commentText'];
            if (strlen($text) < 1) {
                $this->addErrorMessage('The comment cannot be empty');
                return $this->renderView(__FUNCTION__);
            }

            if ($this->db->editComment($comment_id, $text)) {
                $this->addInfoMessage('Comment edited');
                $this->redirect('home');
            } else {
                $this->addErrorMessage('Error editing comment');
                return $this->renderView(__FUNCTION__);
            }
        }

        $_SESSION['comment_id'] = $id;
        $this->renderView(__FUNCTION__, false);
    }

    public function deleteComment($id) {
        $this->admin();
        if ($this->db->deleteComment($id)) {
            $this->addInfoMessage('Comment deleted');
        } else {
            $this->addErrorMessage('Cannot delete comment');
        }

        $this->redirect('home');
    }
}