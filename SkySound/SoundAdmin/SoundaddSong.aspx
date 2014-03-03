<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoundaddSong.aspx.cs" Inherits="SkySound.SoundAdmin.SoundaddSong" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
<meta name="div+css模板,css.gofreeserve.com,Author" content="Author" />
<meta name="div+css模板,css.gofreeserve.com,Robots" content="index,follow" />
<meta name="div+css模板,css.gofreeserve.com,Description" content="Description" />
<meta name="div+css模板,css.gofreeserve.com,Keywords" content="key, words" />
<link rel="stylesheet" type="text/css" href="../images/style.css" />
<title>天籁网站-Sounds of Nature</title>
</head>
<body>
<form id="form1" runat=server>
	<div id="bg">
		<div id="sadrzaj">
			<div id="zaglavlje">
			
				<div id="title">
					<a href="#">Sounds of Nature</a> 
				</div>				
				
					搜索: <asp:DropDownList ID="DropDownList" runat="server">
                   <asp:ListItem Value="category">类别</asp:ListItem>
                    <asp:ListItem Value="name">名称</asp:ListItem> </asp:DropDownList>
               <asp:TextBox ID="TBSearch" runat="server"></asp:TextBox>
                <asp:Button ID="BSearch" runat="server" Text="搜索" onclick="BSearch_Click" />
			</div>

			<div id="navigacija">
				<ul>
					<li><a href="../Default.aspx">网站主页</a></li>
					<li><a href="../SoundAbout.aspx">关于天籁</a></li>
					<li><a href="../SoundSongList.aspx">天籁乐库</a></li>
					<li><a href="../SoundRegister.aspx">会员注册</a></li>
					<li><a href="../Login.aspx">后台管理</a></li>
				</ul>
	
				<div class="lijevo">
					<h3>会员信息</h3>
					<table style="width: 127px">
                      <tr>
                           <td><asp:Label ID="LBName" runat="server" Text="Label">用户名：</asp:Label></td>
                           <td><asp:Label ID="LBNames" runat="server" Text="Label"></asp:Label></td>
                     </tr> 
                     <tr>
                           <td><asp:Label ID="LBUserId" runat="server" Text="Label">昵称：</asp:Label></td>
                           <td><asp:Label ID="LBUserIds" runat="server" Text="Label"></asp:Label></td>
                     </tr> 
                     <tr>
                           <td><asp:Label ID="LBCreateTime" runat="server" Text="Label">创建时间：</asp:Label></td>
                           <td><asp:Label ID="LBCreateTimes" runat="server" Text="Label"></asp:Label></td>
                     </tr>                           
                    </table>
					<div id="infobox">
					   <ul>                           
                            <li><a href="SoundmanageSong.aspx">歌曲管理</a></li>
                            <li><a href="SoundaddSong.aspx">上传歌曲</a></li>
                            <li><a href="SounduserManage.aspx">账号管理</a></li>   
                          
                       </ul>   
					</div>
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			<%--<div class="desna_rubrika">
				<h3>新用户</h3>
				<p>
				<asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>                                
                                <%# Eval("name")%> &nbsp;&nbsp;                           
                               
                                
                        </ItemTemplate>
                        </asp:Repeater>
				</p>
    		</div>--%>

			<div class="lijeva_rubrika">
			<h3>声音管理</h3>
				<table cellpadding="0" cellspacing="0" style="width: 115%">
                    <tr>
                        <td><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                <div id="manageSong" class="commonT">
                    
                    <table>
                    <tr>
                        <td class="style1" >曲名</td>
                        <td class="style2" >分类</td>
                        <td class="style2" >作者</td>
                        <td class="style3" >上传时间</td>
                        <td class="style2">播放次数</td>
                        <td>试听</td>
                        <td>删除</td>
                    </tr>
                      <asp:Repeater ID="RepSeatchMemSong" runat="server">
                        <ItemTemplate>
                                <tr>
                                    <td><%# StringTruncat(Eval("name").ToString(), 10, "...")%></td>
                                    <td><%# StringTruncat(Eval("category").ToString(), 7, "...")%></td>
                                    <td><%# StringTruncat(Eval("singer").ToString(), 7, "...")%></td>
                                    <td><%# Eval("createTime")%></td>
                                    <td><%# Eval("clickCount")%></td>
                                    <td><a href='../play.aspx?id=<%# Eval("id") %>' target="_blank">试听</a></td>
                                    <td>
                                          <asp:LinkButton ID="lbtnDel" OnClientClick="return confirm('确认是否删除')" OnClick="lbtnDel_Click" CommandArgument='<%# Eval("id") %>' runat="server">删除</asp:LinkButton>   
                                    </td>
                                </tr>
                        </ItemTemplate>
                        </asp:Repeater>                     
                    </table>
                    <div id="emptydatass" class="replay" runat="server">
                            <p>您没有上传歌曲！</p>
                    </div>
                    <webdiyer:AspNetPager ID="anps" runat="server"
                             CustomInfoHTML="总计%RecordCount%条记录，共%PageCount%页" FirstPageText="首页" 
                             LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
                             ShowCustomInfoSection="Left" CssClass="paginator" 
                             CurrentPageButtonClass="cpb" AlwaysShow="True" CustomInfoSectionWidth="" 
                             onpagechanged="anp_PageChanged">
                    </webdiyer:AspNetPager>
          
                </div>
                </ContentTemplate>
                </asp:UpdatePanel></td>
                        
                    </tr>
                                           
                    </table>
			</div>
			<%--<div id="downbox">
		<%--<p>上传用户： <asp:Label ID="LBMenId" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       声音名称： <asp:Label ID="LBName" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       声音种类： <asp:Label ID="LBCategory" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       播放次数： <asp:Label ID="LBClickCount" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       上传时间： <asp:Label ID="LBCreateTime" runat="server" Text="Label"></asp:Label></p>
			</div>--%>
			
			<div id="footer">
			    Copyright © 2011 Designed by08计算机软件</div>
		</div>
	</div>
    </form>
</body>
</html>
