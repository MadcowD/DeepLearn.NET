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
			width: 50%;
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
                                <td class ="auto-style4"><strong><u>Proportional Attribute</u></strong></td>
                                <td><strong><u>Value</u></strong></td>
                            </tr>

							<tr>
								<td class="auto-style4">Clump Thickness (% multi-layered)</td>
								<td>
									<asp:TextBox ID="proportion1" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px"
										value='@Request.QueryString["proportion1"]'>0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Cell Size Uniformity (%) </td>
								<td>
									<asp:TextBox ID="proportion2" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Cell Shape Uniformity (%)</td>
								<td>
									<asp:TextBox ID="proportion3" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Marginal Adhesiveness (%)</td>
								<td>
									<asp:TextBox ID="proportion4" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Single Epithelial Cell Size (% larger)</td>
								<td>
									<asp:TextBox ID="proportion5" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Bare Nuclei (% without cytoplasm)</td>
								<td>
									<asp:TextBox ID="proportion6" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Bland Chromatin (% course textured)</td>
								<td>
									<asp:TextBox ID="proportion7" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Normal Nucleoli (%)</td>
								<td>
									<asp:TextBox ID="proportion8" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">Mitosis (% normal activity)</td>
								<td>
									<asp:TextBox ID="proportion9" runat="server" BorderColor="#F4F4F4" BorderStyle="None" MaxLength="3" Width="30px">0</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="auto-style4">
									<asp:Button ID="proportionSubmit" runat="server" OnClick="proportionSubmit_Click" Text="Submit" />
								</td>
								<td>
									&nbsp;</td>
							</tr>
						</table>
						</div>
                    <div class="diagnosis">
							&nbsp;<strong><asp:Label ID="proportionDiagnosis" runat="server" Text="Malignant"></asp:Label></strong>
                        </div>
					</div>
				</div>
			</div>

			<div class='article'>
				<div class='post'>
					<h3>Detailed FNA Test</h3>
					<p> BLAHBLAH BLAH this is atest blah blah blah use this text becasue this a test adn we need need to convey that to the people who we are wrotomg tje trest fpre/ Tjos osss sp,e stipdiudi. DOD YOU SEE MY MEANING</p>
					<div class="tests">
						<table style="width: 100%;">
							<tr>
								<td class="auto-style4"><strong><u>Nucleic Attribute</u></strong></td>
								<td>
									<strong><u>Mean</u></strong> </td> <td> <strong><u>SE</u></strong> </td> <td> <strong><u>Largest</u></strong></td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip" 
                                    detail="The mean of the distances from the center of the nucleus to points on the perimeter.">Radius</td>
								<td>

									<asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>

                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="The standard deviation of grey-scale values of the FNA.">Texture</td>
								<td>
									<asp:TextBox ID="TextBox4" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox6" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="The perimeter of the nucleus.">Perimeter</td>
								<td>
									<asp:TextBox ID="TextBox7" runat="server" Width="50px"></asp:TextBox>
                                </td>                 <td>
                                    <asp:TextBox ID="TextBox8" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox9" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
                            						<tr>
								<td class="auto-style4 tooltip"
                                    detail="The area of the nucleus.">
									Area</td>
								<td>
									<asp:TextBox ID="TextBox10" runat="server" Width="50px"></asp:TextBox>
                                                        </td>                 <td>
                                                            <asp:TextBox ID="TextBox11" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox12" runat="server" Width="50px"></asp:TextBox>
                                                        </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="The local variation in radius lengths.">Smoothness</td>
								<td>
									<asp:TextBox ID="TextBox13" runat="server" Width="50px"></asp:TextBox>
                                </td>                 <td>
                                    <asp:TextBox ID="TextBox14" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox15" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="The squared perimeter over the area less one.">Compactness</td>
								<td>
									<asp:TextBox ID="TextBox16" runat="server" Width="50px"></asp:TextBox>
                                </td>                 <td>
                                    <asp:TextBox ID="TextBox17" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox18" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="The severity of concave portions on the countour of the nucleus.">Concavity</td>
								<td>
									<asp:TextBox ID="TextBox19" runat="server" Width="50px"></asp:TextBox>
                                </td>                 <td>
                                    <asp:TextBox ID="TextBox20" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox21" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="The number of concave points on the contour.">Concave Points</td>
								<td>
									<asp:TextBox ID="TextBox22" runat="server" Width="50px"></asp:TextBox>
                                </td>                 <td>
                                    <asp:TextBox ID="TextBox23" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox24" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="An average measure of symmetry across the nucleus.">Symmetry</td>
								<td>
									<asp:TextBox ID="TextBox25" runat="server" Width="50px"></asp:TextBox>
                                </td>                 <td>
                                    <asp:TextBox ID="TextBox26" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox27" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td class="auto-style4 tooltip"
                                    detail="The coastline approximation less one is the fractal dimension, which is also noted to be an objective and reproducible measure of the complexity of the tissue architecture of the biopsy specimen.">
									Fractal Dimension</td>
								<td>
									<asp:TextBox ID="TextBox28" runat="server" Width="50px"></asp:TextBox>
                                </td>                 <td>
                                    <asp:TextBox ID="TextBox29" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox30" runat="server" Width="50px"></asp:TextBox>
                                </td>
							</tr>
	
							<tr>
								<td class="auto-style4">
									<asp:Button ID="detailSubmit" runat="server" OnClick="detailSubmit_Click" Text="Submit" />
                                </td>
								<td>
									&nbsp;</td>
							</tr>
						</table>
						</div>
                    <div class="diagnosis">
							&nbsp;<strong><asp:Label ID="detailDiagnosis" runat="server" Text="Malignant"></asp:Label></strong>
                        </div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
