<?
/***************************************************************************

pseudo-cron
(c) 2003,2004 Kai Blankenhorn
www.bitfolge.de/pseudocron
kaib@bitfolge.de


This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

****************************************************************************

This script can be called using an HTML img tag, for example:

<img src="pseudo-cron-image.php" width="1" height="1" alt="" />

The two files pseudo-cron.inc.php and pseudo-cron-image.php must be in the
same directory on the server.
The advantage of using this script is that pseudocron is called in a separate
request and thus does not slow down output of the main page as it would if called
from there.

***************************************************************************/

Header("Content-Type: image/gif");

include("pseudo-cron.inc.php");

echo base64_decode("R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==");
?>