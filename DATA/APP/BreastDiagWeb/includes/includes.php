<?php
include 'gist.php';
include 'SQLHelper.php';
include 'HTTPHelper.php';

function GetBlogPosts($count, $inId=null)
{
	if (!empty($inId))
	{
		$query = SQLHelper::query("SELECT * FROM gists WHERE id = " . $inId . " ORDER BY id DESC"); 
	}
	else
	{
		$query = SQLHelper::query("SELECT * FROM gists ORDER BY id DESC");
	} 
	
	$postArray = array();
	while ($row = SQLHelper::fetchByAssoc($query))
	{
			$myPost = new BlogPost($row["id"], $row['gist'], $row['gist_raw'], $row['date']);
			array_push($postArray, $myPost);
	}
	if($count > count($postArray))
		$count = count($postArray);
	
	return array_slice($postArray, -$count);
}
?>
