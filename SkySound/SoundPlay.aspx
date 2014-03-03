<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoundPlay.aspx.cs" Inherits="SkySound.SoundPlay1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />

<link rel="stylesheet" type="text/css" href="images/style.css" />
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
					<li><a href="Default.aspx">网站主页</a></li>
					<li><a href="SoundAbout.aspx">关于天籁</a></li>
					<li><a href="SoundSongList.aspx">天籁乐库</a></li>
					<li><a href="SoundRegister.aspx">会员注册</a></li>
					<li><a href="SoundAdmin/Login.aspx">后台管理</a></li>
				</ul>
	
				<div class="lijevo">
					<h3>最新歌曲</h3>
					<table>
                    <tr>
                        <td>曲名</td>
                        <td>分类</td>
                    </tr>
                      <asp:Repeater ID="RepSelectNewS" runat="server">
                        <ItemTemplate>
                                <tr>
                                    <td><a href='SoundPlay.aspx?id=<%# Eval("id") %>' target="_blank"><%# StringTruncat(Eval("name").ToString(), 7, "...")%></a></td>
                                    <td><%# Eval("category")%></td>
                                </tr>
                        </ItemTemplate>
                        </asp:Repeater>                     
                    </table>
					
					
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			

			<div class="lijeva_rubrika">
			<h3>播放歌曲</h3>
				<table cellpadding="0" cellspacing="0" width=96%>
                    <tr>
                        <td><object id="player" height="150" width="400" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
                        <param name="AutoStart" value="-1"/>
                        <!--是否自动播放-->
                        <param name="Balance" value="0"/>
                        <!--调整左右声道平衡,同上面旧播放器代码-->
                        <param name="enabled" value="-1"/>
                        <!--播放器是否可人为控制-->
                        <param name="EnableContextMenu" value="-1"/>
                        <!--是否启用上下文菜单-->   
                              <asp:Repeater ID="RepSong" runat="server">
                            <ItemTemplate>
                                    <param id="c" name="url" value="<%# Eval("content") %>"/>
                            </ItemTemplate>
                            </asp:Repeater>
                        <!--播放的文件地址-->
                        <param name="PlayCount" value="1"/>
                        <!--播放次数控制,为整数-->
                        <param name="rate" value="1"/>
                        <!--播放速率控制,1为正常,允许小数,1.0-2.0-->
                        <param name="currentPosition" value="0"/>
                        <!--控件设置:当前位置-->
                        <param name="currentMarker" value="0"/>
                        <!--控件设置:当前标记-->
                        <param name="defaultFrame" value=""/>
                        <!--显示默认框架-->
                        <param name="invokeURLs" value="0"/>
                        <!--脚本命令设置:是否调用URL-->
                        <param name="baseURL" value=""/>
                        <!--脚本命令设置:被调用的URL-->
                        <param name="stretchToFit" value="1"/>
                        <!--是否按比例伸展-->
                        <param name="volume" value="50"/>
                        <!--默认声音大小0%-100%,50则为50%-->
                        <param name="mute" value="0"/>
                        <!--是否静音-->
                        <param name="uiMode" value="Full"/>
                        <!--播放器显示模式:Full显示全部;mini最简化;None不显示播放控制,只显示视频窗口;invisible全部不显示-->
                        <param name="windowlessVideo" value="0"/>
                        <!--如果是0可以允许全屏,否则只能在窗口中查看-->
                        <param name="fullScreen" value="0"/>
                        <!--开始播放是否自动全屏-->
                        <param name="enableErrorDialogs" value="-1"/>
                        <!--是否启用错误提示报告-->
                        <param name="SAMIStyle" />
                        <!--SAMI样式-->
                        <param name="SAMILang" />
                        <!--SAMI语言-->
                        <param name="SAMIFilename" />
                        <!--字幕ID-->
                    </object></td>
                        
                    </tr>
                                           
                    </table>
			</div>
			<div id="downbox">
			<p>上传用户： <asp:Label ID="LBMenId" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       声音名称： <asp:Label ID="LBName" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       声音种类： <asp:Label ID="LBCategory" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       播放次数： <asp:Label ID="LBClickCount" runat="server" Text="Label"></asp:Label>
                       &nbsp;
                       上传时间： <asp:Label ID="LBCreateTime" runat="server" Text="Label"></asp:Label></p>
			</div>
			
			<div id="footer">
			    Copyright © 2011 Designed by 类菌体</div>
		</div>
	</div>
    </form>
</body>
</html>
