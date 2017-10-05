using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

//这个类用来绑定
public class Demo_MVCSContext : MVCSContext {
    //构造函数，给父类传一个view对象，就是context要绑定的物体
    public Demo_MVCSContext(MonoBehaviour view):base(view) { }
    
    //进行绑定映射，这里的绑定都是全局的，都要用全局的派发器
    protected override void mapBindings()
    {
        //Model
        //接口和自身做绑定，用自身构造
        injectionBinder.Bind<FightingCommon>().To<FightingCommon>().ToSingleton();
        injectionBinder.Bind<RoleModel>().To<RoleModel>().ToSingleton();
        injectionBinder.Bind<MapModel>().To<MapModel>().ToSingleton();

        //Command
        commandBinder.Bind(ViewEvent.TestDug).To<TestCommand>();
        commandBinder.Bind(GameConfig.CoreEvent.USER_INPUT).To<OperationCommand>();//用户输入指令和操作绑定
        commandBinder.Bind(CommandEvent.CamCW).To<CamTurnCommand>();
        commandBinder.Bind(CommandEvent.CamCCW).To<CamTurnCommand>();

        //把View和Mediator绑定，绑定之后Mediator的创建交给StrangeIoc
        mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
        mediationBinder.Bind<OperationView>().To<OperationMediator>();
        mediationBinder.Bind<TestView>().To<TestMediator>();
        mediationBinder.Bind<CamView>().To<CamMediator>();


        //Service

        //Manager

        if (this == Context.firstContext)
        {
            injectionBinder.Bind<User>().CrossContext().ToSingleton();
            injectionBinder.Bind<DataBaseCommon>().CrossContext().ToSingleton();
            injectionBinder.Bind<IUnitAPI>().To<CustomAPI>().CrossContext().ToSingleton();
        }

        //全部绑定完成后执行开始命令
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
