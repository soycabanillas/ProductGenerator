namespace ApiGenerator.TemplateEngine

module EngineExecutor =
    type Model =
      { Name : string }
    let execute filePath model =
        Suave.DotLiquid.setCSharpNamingConvention()
        Suave.DotLiquid.renderPageFile filePath model