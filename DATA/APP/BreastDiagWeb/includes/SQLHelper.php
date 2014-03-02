<?php
class SQLHelper
{
	private static $connection;
	private static $database;
	public static function init()
	{
		self::$connection = mysql_connect('localhost', 'wguss', 'Sh@yna06') or die ("<p class='error'>Sorry, we were unable to connect to the database server.</p>");
		self::$database = "wguss_sql";
		mysql_select_db(SQLHelper::$database, SQLHelper::$connection) or die ("<p class='error'>Sorry, we were unable to connect to the database.</p>");
	}
	
	public static function query($query)
	{
		return mysql_query($query);
	}
	
	public static function fetchByAssoc($queryz)
	{
		return mysql_fetch_assoc($queryz);
	}
	
}

SQLHelper::init();
?>