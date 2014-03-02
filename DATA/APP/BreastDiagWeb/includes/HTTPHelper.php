<?php
class HTTPHelper
{
	public static function request($url, $method, $header, $content){
		// use key 'http' even if you send the request to https://...
		$options = array(
			'http' => array(
				'header'  => $header . "\nUser-Agent: Apache HTTPClient",
				'method'  => $method,
				'content' => $content,
			),
		);
		$context  = stream_context_create($options);
		$result = file_get_contents($url, false, $context);
		return $result;
	}
	
	public static function arrayToConent($data){
		return http_build_query($data);
	}
	
}
?>