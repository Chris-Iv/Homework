<?php

class BooksController extends BaseController {
    private $db;

    public function onInit() {
        $this->title = 'Books';
        $this->db = new BooksModel();
    }

    public function index($page = DEFAULT_PAGE, $pageSize = DEFAULT_PAGE_SIZE) {
        $this->authorize();
        $form = $page * $pageSize;
        $this->page = $page;
        $this->pageSize = $pageSize;
        $this->books = $this->db->getFilteredBooks($form, $pageSize);
        $this->renderView(__FUNCTION__);
    }

    public function showBooks() {
        $this->authorize();
        $this->books = $this->db->getAll();
        $this->renderView(__FUNCTION__, false);
    }
}