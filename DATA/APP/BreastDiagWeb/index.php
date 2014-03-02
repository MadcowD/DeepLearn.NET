<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>William Guss</title>

</head>
<body>
<div class="header">
	<h1>William Guss</h1>
	<h2>void helloWorld()</h2>
</div>
<div class="navbar">
	<table width="400" border="0" align="center" class="links">
	  <tr>
		<td><a href="http://resume.wguss.com">Résumé</a></td>
		<td><a href="./projects">Projects</a></td>
		<td><a href="./contact">Contact</a></td>
	  </tr>
	</table>
</div>
<div class="content">
<?php
include "includes/includes.php";

$posts = GetBlogPosts(30, null, null);

foreach($posts as $post)
{
	if(!empty($post->gist_url))
	{
		echo "<div class='article'><div class='post'>";
		echo "<h3>" . $post->gist_url . "</h3>";
		echo "<p>" . $post->gist_raw . "</p>";
		echo "</div></div>";
	}
}
?>
</div>
<img src="includes/pseudo-cron-image.php" width="1" height="1" alt="" />
</body>
</html>
