import System.Web.Mvc
import MavenThought.MediaLibrary.WebClient.Controllers
import MavenThought.MediaLibrary.WebClient.ViewModels
import MavenThought.MediaLibrary.Storage.NHibernate
import MavenThought.MediaLibrary.Domain

component "HomeController", HomeController:
  @lifestyle = "transient"

component "AboutController", AboutController:
  @lifestyle = "transient"

component "FightController", FightController:
  @lifestyle = "transient"

component ICalculatorViewModel, CalculatorViewModel:
  @lifestyle = "transient"

component INinjaCommander, StorageNinjaCommander:
  databaseFile = "C:/temp/ninjacommander.db"
