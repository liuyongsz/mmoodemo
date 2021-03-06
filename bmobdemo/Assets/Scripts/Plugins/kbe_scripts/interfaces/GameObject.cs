namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;

    public class GameObject : if_Entity_error_use______git_submodule_update_____kbengine_plugins_______open_this_file_and_I_will_tell_you
    {
        public GameObject()
        {
        }

        /*
			以下函数是实体的属性被设置时插件底层调用
			set_属性名称(), 想监听哪个属性就实现该函数，事件触发后由于world.cs中监听了该事件，world.cs会取出数据做行为表现。
			另外，这些属性如果需要同步到客户端，前提是在def中定义过该属性，并且属性的广播标志为ALL_CLIENTS、OTHER_CLIENTS、等等，
			参考：http://www.kbengine.org/cn/docs/programming/entitydef.html
			
			实际下列函数可以再抽象出一些层次 
			例如Combat.cs对应服务端demo中的kbengine_demos_assets\scripts\cell\interfaces\Combat.py|CombatPropertys.py, 
			像HP、MP、recvDamage都属于战斗相关
			
			set_state可以放到State.cs对应服务端的State.py
			这里请原谅我偷个懒， 全部放在逻辑实体基础对象了
		*/

    }
    
} 
