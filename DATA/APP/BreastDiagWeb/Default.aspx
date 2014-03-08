<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BreastDiagWeb.Default" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href='http://fonts.googleapis.com/css?family=Oleo+Script:400,700&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
	<link href="media/styles/index.css" rel="stylesheet" type="text/css" />
	<title>Cancer</title>
    <style type="text/css">
        .auto-style4 {
            width: 269px;
        }
    </style>
</head>
<body>
	<form id="form1" runat="server">
		<div class="header">
			<h1>Breast Cancer Diagnostics</h1>
		</div>
		<div class="navbar">
			<table width="400" border="0" align="center" class="links">
			  <tr>
				<td><a href="#">Diagnostic</a></td>
				<td><a href="./project.aspx">Project Page</a></td>
				<td><a href="./contact.aspx">Contact</a></td>
			  </tr>
			</table>
		</div>
		<div class="content">
			<div class='article'>
				<div class='post'>
					<h3>Abstract</h3>
					<p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
				    <p> Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?</p>
                </div>
			</div>

            <div class='article'>
				<div class='post'>
					<h3>Proportional FNA Test</h3>
                    <p> BLAHBLAH BLAH this is atest blah blah blah use this text becasue this a test adn we need need to convey that to the people who we are wrotomg tje trest fpre/ Tjos osss sp,e stipdiudi. DOD YOU SEE MY MEANING</p>
                    <div class="tests">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style4">Clump Thickness (% multi-layered)</td>
                                <td>
                                    <asp:TextBox ID="proportion1" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"
                                        value='@Request.QueryString["proportion1"]'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Cell Size Uniformity (%) </td>
                                <td>
                                    <asp:TextBox ID="proportion2" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Cell Shape Uniformity (%)</td>
                                <td>
                                    <asp:TextBox ID="proportion3" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Marginal Adhesiveness (%)</td>
                                <td>
                                    <asp:TextBox ID="proportion4" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Single Epithelial Cell Size (% larger)</td>
                                <td>
                                    <asp:TextBox ID="proportion5" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Bare Nuclei (% without cytoplasm)</td>
                                <td>
                                    <asp:TextBox ID="proportion6" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Bland Chromatin (% course textured)</td>
                                <td>
                                    <asp:TextBox ID="proportion7" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Normal Nucleoli (%)</td>
                                <td>
                                    <asp:TextBox ID="proportion8" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Mitosis (% normal activity)</td>
                                <td>
                                    <asp:TextBox ID="proportion9" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </div>
                        <p>
                            Diagnosis: <strong><asp:Label ID="proportionDiagnosis" runat="server" Text="Malignant"></asp:Label></strong>
                        </p>
                    </div>
                </div>
			</div>

            <div class='article'>
				<div class='post'>
					<h3>Detailed FNA Test</h3>
					<p>Here is test2: </p>
                </div>
			</div>
		</div>
	</form>
</body>
</html>
