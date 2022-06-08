import {
  Column,
  Entity,
  JoinColumn,
  JoinTable,
  ManyToMany,
  OneToOne,
} from 'typeorm';
import { BaseTaggedEntity } from './base.tagged.entity';
import { User } from './user.entity';
import { Location } from './location.entity';

@Entity({ name: 'custs_sub_acct' })
export class CustomerSub extends BaseTaggedEntity {
  @Column()
  public name: string;

  @ManyToMany(() => User)
  public users!: User[];

  @OneToOne(() => User)
  @JoinColumn()
  public manager!: User;

  @ManyToMany(() => User)
  @JoinTable()
  public contacts!: User[];

  @ManyToMany(() => Location)
  public locations!: Location[];

  @Column({ type: 'text' })
  public description: string;
}
