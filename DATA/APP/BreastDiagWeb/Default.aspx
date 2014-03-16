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
					<td><a href="./project.aspx">Paper</a></td>
					<td><a href="mailto:carlostnb@gmail.com">Contact</a></td>
				  </tr>
				</table>
			</div>
			<div class="content">
				<div class='article'>
					<div class='post'>
						<h3>Abstract</h3>
						<p> The challenge of diagnosing cancer is that no single test can accurately succeed. Diagnostic testing is essential to evaluate the health of an individual and determine whether the individual has cancer. Diagnostic imaging is a useful technique to produce an internal picture of the body for analyzing structure. However, medical professionals are required to successful analyze the images and determine whether the individual has cancer. Applying artificial neural networks to this problem makes the analysis more efficient while minimizing error in diagnosis.</p>
						<p> The purpose of the project is to implement a successful neural network with backpropagation to analyze a breast cancer numerical and image dataset. It also evaluates the efficiency of the network as it is influenced by different conditions. The efficiency is gauged by the error percentages accumulated by the network. Furthermore, statistical analysis is applied to the network in order to analyze the effectiveness.</p>
						<p>The project showed that despite the adaptability of the neural network, it is still unable to remove the error completely. While neural networks are useful, they cannot be relied on completely. However, there is a tradeoff between error and flexibility in the network. While the error has the potential to be removed from the testing of the neural network, the network would be over fitted to the dataset it is being trained and tested on so that it would lose its ability to successfully analyze similar forms of data.</p>
					</div>
				</div>

				<div class='article'>
					<div class='post'>
						<h3>Proportional FNA Test</h3>
						<p>This dataset is numerical and multivariate with integer attribute values. The creator was Dr. William H. Wolberg at the University of Wisconsin in Madison, Wisconsin. The diagnostic test created for this specific dataset is called a P-FNA test, proportional fine needle aspiration test.</p>
						<p>The dataset used had 9 input attributes, each from a range of 1 to 10. There were a total of 699 data points. However, 16 of the points had inconsistencies where a question mark stood in place of a number. The 16 data points thus were excluded from both the training and the testing of the neural network. 10 percent of the data was used for testing while the other 90 percent were used for training.</p>
						<p>While the data had the output of 2 for benign and 4 for malignant, during the testing of the network these numbers were changed to 0 and 1 for benign and malignant respectively. This is because the logistic function can only output from a range of -1 to 1. For the actual dataset, 65.5% were benign and the other 35.5 percent were malignant. The source also claimed that there is also a 5% discrepancy in the dataset.</p>
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
						<p> This dataset is numerical and multivariate with real attribute values. The creator was Dr. William H. Wolberg at the University of Wisconsin in Madison, Wisconsin. The diagnostic test created for this specific dataset is called a D-FNA test, detailed fine needle aspiration test.</p>
						<p>The dataset used had 30 input attributes, each represented by a real value with four significant digits. Ten features are computed from a digitized image of a fine needle aspirate (FNA) of a breast mass. They describe characteristics of the cell nuclei present in the image. The mean, standard error, and largest of these features were computed for each image, resulting in 30 real valued features. There were a total of 569 data points. 10 percent of the data was used for testing while the other 90 percent were used for training.</p>
						<p>While the data had the output of B for benign and M for malignant, during the testing of the network these numbers were changed to 0 and 1 for benign and malignant respectively. This is because output of the neural network is a numerical value. For the actual dataset, 62.7% were benign and the other 37.3% were malignant.</p>
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
				<div class='article'>
					<div class='post'>
						<h3>Mammographic Imaging Diagnostic</h3>
						<p>This dataset is composed of images from mammographies. The creator was the Mammographic Image Analysis Society. The diagnostic test created for this specific dataset is called a MID test, mammography image diagnostic test. </p>
						<p>The dataset is composed of images with 200 micron pixel edges. Each image size is  1024x1024 pixels. 18.2 percent of the data was used for testing while the other 81.8 percent were used for training. The breasts that were in the dataset had three distinct background tissues: fatty, fatty-glandular, and dense-glandular. Only images with fatty background tissue were used during the experiment to reduce a variable for the network. Also only images of left breasts were used to reduce the amount of uncertainty in the network because of the existence of black space on either side of the breast. Once these specific images were separated from the original dataset, a total of 22 images remained. Of these 11 were tumorous and 11 were normal (more normal ones existed but in order to achieve consistency during training and testing only 11 were used).</p>
							
						<p><b><u><asp:Label ID="Label1" runat="server" Text="Upload Mammographic Image"></asp:Label></u></b></p>
							
						<div class="lbl">
									<asp:Label ID="Label2" runat="server" CssClass="lbl"  Text="Raw Image" Visible="false"></asp:Label><br />
									<asp:Image ID="Image1" runat="server" CssClass="lbl" /><br />
									<asp:Label ID="Label3" runat="server" Text="Post-DWT" Visible="false"></asp:Label><br />
									<asp:Image ID="Image2" runat="server" Visible ="false" />
						</div>
		  
						<p>                            
							<asp:FileUpload ID="midImage" runat="server" Width="100%" /><br />
							<asp:Button ID="midSubmit" runat="server" OnClick="midSubmit_Click" Text="Submit" />
						</p>
						<div class="diagnosis">
						&nbsp;<strong><asp:Label ID="midDiagnosis" runat="server" Text=""></asp:Label></strong>
					 </div>
				</div>
		</form>
	</body>
</html>
