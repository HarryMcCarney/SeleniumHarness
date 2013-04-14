<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head profile="http://selenium-ide.openqa.org/profiles/test-case">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link rel="selenium.base" href="https://startpage.com/" />
<title>LL_Tabs</title>
</head>
<body>
<table cellpadding="1" cellspacing="1" border="1">
<thead>
<tr><td rowspan="1" colspan="3">LL_Tabs</td></tr>
</thead><tbody>
<tr>
	<td>store</td>
	<td>http://demo.larryslist.de/</td>
	<td>demo</td>
</tr>
<tr>
	<td>store</td>
	<td>http://dev.larryslist.de/</td>
	<td>dev</td>
</tr>
<tr>
	<td>setSpeed</td>
	<td>200</td>
	<td></td>
</tr>
<tr>
	<td>open</td>
	<td>${dev}logout</td>
	<td></td>
</tr>
<tr>
	<td>waitForElementPresent</td>
	<td>link=What You Get</td>
	<td></td>
</tr>
<tr>
	<td>click</td>
	<td>link=What You Get</td>
	<td></td>
</tr>
<tr>
	<td>pause</td>
	<td>500</td>
	<td></td>
</tr>
<tr>
	<td>click</td>
	<td>link=Pricing</td>
	<td></td>
</tr>
<tr>
	<td>pause</td>
	<td>500</td>
	<td></td>
</tr>
<tr>
	<td>click</td>
	<td>link=Collector Ranking</td>
	<td></td>
</tr>
<tr>
	<td>pause</td>
	<td>500</td>
	<td></td>
</tr>
<tr>
	<td>waitForElementPresent</td>
	<td>//div[3]/div[2]/div/p[2]/a</td>
	<td></td>
</tr>
<tr>
	<td>verifyTextPresent</td>
	<td>Learn more here.</td>
	<td></td>
</tr>
<tr>
	<td>click</td>
	<td>link=Learn more here.</td>
	<td></td>
</tr>
<tr>
	<td>waitForElementPresent</td>
	<td>css=h1.title</td>
	<td></td>
</tr>
<tr>
	<td>highlight</td>
	<td>css=h1.title</td>
	<td></td>
</tr>
<tr>
	<td>goBackAndWait</td>
	<td>void:GoBack();</td>
	<td></td>
</tr>
<tr>
	<td>open</td>
	<td>${dev}logout</td>
	<td></td>
</tr>
<tr>
	<td>click</td>
	<td>link=Data Sources</td>
	<td></td>
</tr>
<tr>
	<td>waitForElementPresent</td>
	<td>//div[4]/div[2]/div/p[2]/a</td>
	<td></td>
</tr>
<tr>
	<td>verifyTextPresent</td>
	<td>Test us.</td>
	<td></td>
</tr>
<tr>
	<td>click</td>
	<td>//div[4]/div[2]/div/p[2]/a</td>
	<td></td>
</tr>
<tr>
	<td>pause</td>
	<td>500</td>
	<td></td>
</tr>
<tr>
	<td>highlight</td>
	<td>css=label.control-label.search-title</td>
	<td></td>
</tr>
<tr>
	<td>pause</td>
	<td>500</td>
	<td></td>
</tr>
<tr>
	<td>highlight</td>
	<td>css=div.control-group.last &gt; label.control-label.search-title</td>
	<td></td>
</tr>
<tr>
	<td>pause</td>
	<td>500</td>
	<td></td>
</tr>
<tr>
	<td>click</td>
	<td>link=exact:Who is Larry?</td>
	<td></td>
</tr>
</tbody></table>
</body>
</html>
