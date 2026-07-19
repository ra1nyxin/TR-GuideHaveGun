# 向导改用战术霰弹枪 | Guide Uses a Tactical Shotgun

这个模组只修改原版向导的战斗表现。 | This mod only changes the vanilla Guide's combat behavior.
向导不再使用原版默认弓箭，而是改为使用战术霰弹枪造型与子弹攻击。 | The Guide no longer uses the default bow and instead attacks with a Tactical Shotgun-style weapon and bullets.
向导每次攻击后的等待时间会明显缩短，因此会更频繁地对附近敌怪开火。 | The wait time after each attack is cut down noticeably, so the Guide fires at nearby enemies more often.
向导识别并攻击敌怪的距离提升到默认值的三倍，更早开始压制靠近的怪。 | The Guide's enemy detection and attack distance is raised to three times the default range, so he starts shooting much earlier.

## 功能 | Features

仅作用于原版向导 NPC。 | Applies only to the vanilla Guide NPC.
攻击投射物改为子弹。 | Replaces the attack projectile with bullets.
攻击冷却进一步缩短，提高向导的持续防守能力。 | Further shortens the attack cooldown to improve the Guide's ability to protect players.
索敌距离提升到 600 像素。 | Raises enemy detection distance to 600 pixels.
实现方式基于原版城镇 NPC 攻击 Hook，不替换向导 AI 主体。 | Implemented through vanilla town NPC attack hooks without replacing the Guide's core AI.

## 兼容性 | Compatibility

兼容 tModLoader 与常见大型内容模组。 | Compatible with tModLoader and common large content mods.
只覆盖向导的攻击参数与武器绘制，不修改其他 NPC，也不依赖灾厄专用适配。 | Only overrides the Guide's attack parameters and weapon draw, does not modify other NPCs, and does not require Calamity-specific patches.
如果其他模组也直接改写向导的同类攻击 Hook，最终效果取决于加载后的实际覆盖顺序。 | If another mod also rewrites the same Guide attack hooks, the final result depends on the effective load order and override outcome.
