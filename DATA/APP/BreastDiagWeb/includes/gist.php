<?php
class BlogPost
{
	public $id;
	public $gist_url;
	public $gist_raw;
	public $dateTimePosted;
	public $comment_count;
	
	function __construct($idIn, $gist_urlIn, $gist_rawIn, $dateTimePostedIn)
	{
		$this->id = $idIn;
		$this->gist_url = $gist_urlIn;
		$this->gist_raw = $gist_rawIn;
		$this->dateTimePosted = $dateTimePostedIn;
	}
	
	public function getData()
	{
		return file_get_contents($this->gist_raw);
	}
}
?>