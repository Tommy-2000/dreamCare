import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../logic/providers/common/common_ui_providers.dart';
import '../../../logic/utils/constants.dart';
import '../../../styles/colours.dart';
import '../../common/buttons/primary_button.dart';
import '../../common/cards/persistent_header_card.dart';
import '../../common/cards/content_card.dart';
import '../../common/cards/chart_cards/stat_card.dart';
import '../../common/cards/monthly_calendar_card.dart';
import '../../state/schedule_event.dart';
import '../../state/schedule_state.dart';

class ScheduleScreen extends ConsumerStatefulWidget with ScheduleState, ScheduleEvent {
  const ScheduleScreen({super.key});

  @override
  ConsumerState<ScheduleScreen> createState() => _ScheduleScreenState();
}

class _ScheduleScreenState extends ConsumerState<ScheduleScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(screenGridPadding),
      child: CustomScrollView(
        slivers: <Widget>[
          SliverToBoxAdapter(
            child: ContentCard(
              child: Text(
                "Appointments",
                style: GoogleFonts.montserrat(
                  fontSize: 25,
                  fontWeight: FontWeight.bold,
                  color: primaryTextColour,
                ),
              ),
            ),
          ),
          SliverGap(5),
          SliverToBoxAdapter(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                PrimaryButton(buttonText: "Import Member",
                    buttonIcon: Icon(Icons.cloud_upload_rounded, size: 15.0)),
                Gap(5),
                PrimaryButton(buttonText: "New Member",
                    buttonIcon: Icon(Icons.add_rounded, size: 15.0)),
              ],
            ),),
          SliverGap(5),
          paintHeaderCard("Upcoming Appointments"),
          SliverGrid(
            gridDelegate: SliverQuiltedGridDelegate(
              crossAxisCount: 32,
              pattern: [
                QuiltedGridTile(8, 8),
                QuiltedGridTile(8, 8),
                QuiltedGridTile(8, 8),
                QuiltedGridTile(8, 8),
                QuiltedGridTile(16, 16),
                QuiltedGridTile(16, 16),
              ],
            ),
            delegate: SliverChildListDelegate([
              ContentCard(child: Icon(Icons.access_alarm_rounded)),
              ContentCard(child: Icon(Icons.read_more_rounded)),
              StatCard(
                statIcon: Icons.group_rounded,
                statTitle: ref.read(testTextProvider),
                statNumber: 20,
              ),
              ContentCard(child: Icon(Icons.read_more_rounded)),
              MonthlyCalendarCard(),
            ]),
          ),
        ],
      ),
    );
  }
}

