using Oxide.Core.Libraries.Covalence;
using Oxide.Game.Rust.Cui;

namespace Oxide.Plugins
{
    // Simple example for working with the Rust CUI system.
    // First build the basic UI shape using the web tool: https://rust-cui.surge.sh/#!/editor
    // Then, tweak the resulting template in game to get the details right
    [Info("GuiTest", "open_mailbox", "0.0.1")]
    class GuiTest : CovalencePlugin
    {
        #region json
        private static string TEMPLATE = @"
        [
          {
            ""name"": ""HelloWorld"",
            ""parent"": ""Hud"",
            ""components"": [
              {
                ""type"": ""UnityEngine.UI.Image"",
                ""color"": ""1 1 1 1""
              },
              {
                ""type"": ""RectTransform"",
                ""anchormin"": ""0.357 0.454"",
                ""anchormax"": ""0.513 0.663""
              },
              {
                ""type"": ""NeedsCursor""
              }
            ]
          },
          {
            ""name"": ""f96a-e995-af1d"",
            ""parent"": ""HelloWorld"",
            ""components"": [
              {
                ""type"": ""UnityEngine.UI.Text"",
                ""color"": ""1 0 0 1"",
                ""fontSize"": 14,
                ""align"": ""MiddleCenter"",
                ""text"": ""{labeltext}""
              },
              {
                ""type"": ""RectTransform"",
                ""anchormin"": ""0.31 0.593"",
                ""anchormax"": ""0.695 0.707""
              }
            ]
          },
          {
            ""name"": ""8f66-03f8-9c3a"",
            ""parent"": ""HelloWorld"",
            ""components"": [
              {
                ""type"": ""UnityEngine.UI.Button"",
                ""command"": ""guitest.close"",
                ""close"": """",
                ""color"": ""0.31 0.31 0.31 1""
              },
              {
                ""type"": ""RectTransform"",
                ""anchormin"": ""0.385 0.093"",
                ""anchormax"": ""0.635 0.427""
              }
            ]
          },
          {
            ""name"": ""a7dd-4c1d-71fb"",
            ""parent"": ""8f66-03f8-9c3a"",
            ""components"": [
              {
                ""type"": ""UnityEngine.UI.Text"",
                ""color"": ""1 1 1 1"",
                ""fontSize"": 14,
                ""align"": ""MiddleCenter"",
                ""text"": ""{buttontext}""
              },
              {
                ""type"": ""RectTransform"",
                ""anchormin"": ""0 0"",
                ""anchormax"": ""1 1""
              }
            ]
          }
        ]
        ";
        #endregion

        [Command("guitest")]
        private void CommandGuiTest(IPlayer player, string command, string[] args)
        {
            var bPlayer        = (BasePlayer)player.Object;
            var labelText      = "Hello World!";
            var buttonText     = "Close";
            var filledTemplate = TEMPLATE.Replace("{labeltext}", labelText).Replace("{buttontext}", buttonText);

            CuiHelper.DestroyUi(bPlayer, "HelloWorld");
            CuiHelper.AddUi(bPlayer, filledTemplate);
        }

        [Command("guitest.close")]
        private void CommandGuiTestClose(IPlayer player, string command, string[] args)
        {
            player.Reply("Closing menu!");
            CuiHelper.DestroyUi((BasePlayer)player.Object, "HelloWorld");
        }
    }
}
